import time
import sys
import usb.core
import json
import config
import track
import requests;

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

def dumpUsb():
    # find USB devices
    dev = usb.core.find(find_all=True)
    for cfg in dev:
        print cfg
        sys.stdout.write('Decimal VendorID=' + str(cfg.idVendor) + ' & ProductID=' + str(cfg.idProduct) + '\n')
        sys.stdout.write('Hexadecimal VendorID=' + hex(cfg.idVendor) + ' & ProductID=' + hex(cfg.idProduct) + '\n\n')

def postEvent(config, message):
    tracked=track.Track(message, config.gateId)
    str=json.dumps(tracked, cls=track.TrackEncoder)

    r = requests.post(config.route, data=str)
    if(r.status_code==200):
        print r.json()

        
card = '0019171125'
def main():
    config=initialize()
    postEvent(config, "salut")
    exit()

    #dumpUsb()

    while True:
        sys.stdin = open('/dev/tty0', 'r')
        RFID_input = input()
        if RFID_input == card:
            print "Access Granted"
            print "Read code from RFID reader:{0}".format(RFID_input)
        else:
            print "Access Denied"
            tty.close()
main()