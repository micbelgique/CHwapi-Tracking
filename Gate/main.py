import time
import sys
import json
import config
import track
import requests
import time

import serial

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
    tracked=track.Track(message, config.gateId)
    str=json.dumps(tracked, cls=track.TrackEncoder)

    r = requests.post(config.route, data=str)
    if(r.status_code==200):
        print r.json()
    else:
        print "code: {0}".format(r.status_code)


def main():
    config=initialize()
    #postEvent(config, "salut")

    while True:
        ser = serial.Serial("COM3", 115200)
        message=ser.readline()
        while (message):
            print message
            if "message: " in message:
                message = message[9:]
                print("post: "+message)
                postEvent(config, message)

            message=ser.readline()

        ser.close()
        print "minibreak"
        time.sleep(1)

    exit()

    #dumpUsb()
main()