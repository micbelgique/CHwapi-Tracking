import time
import sys
import json
import config
import track
import requests
import getopt
import time

import serial

DEFAULT_PORT = "COM3";

def as_config(dictionary):
    return config.Config(dictionary['gateId'], dictionary['route'])

def initialize():
    f=open('config.json', 'r')

    print(f)
    jsonData=f.read()
    print(jsonData)

    config=json.loads(jsonData, object_hook=as_config)
    print "Gate ID: {0}".format(config.gateId)
    print "Gate Route: {0}".format(config.route)

    return config

def postEvent(config, message):
    objectMessage=json.loads(message)
    tracked=track.Track(objectMessage, config.gateId)
    str=json.dumps(tracked, cls=track.TrackEncoder)

    print str;

    headers = {'user-agent': 'gate/0.0.1', 'content-type': 'application/json;charset=UTF-8'}
    r = requests.post(config.route, data=str, headers=headers)
    if(r.status_code==200):
        print r.json()
    else:
        print "code: {0}".format(r.status_code)

def getSerialPort(argv):
    for arg in sys.argv:
        if "--serial:" in arg:
            return arg[9:];

    return DEFAULT_PORT;

def main(argv):
    config=initialize()
    config.port=getSerialPort(argv);

    print "start listening on port '{0}'".format(config.port);

    while True:
        ser = serial.Serial(config.port, 115200)
        message=ser.readline()
        while (message):
            print message
            if "gate: " in message:
                message = message[6:]
                config.gateId=int(message.rstrip('\n').rstrip('\r'));
                print config.gateId

            if "message: " in message:
                message = message[9:]
                print("post: "+message)
                postEvent(config, message)

            message=ser.readline()

        ser.close()

    exit()

    #dumpUsb()
main(sys.argv[1:])