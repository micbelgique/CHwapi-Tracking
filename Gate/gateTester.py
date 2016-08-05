import os
import sys
import time

#http://raspberrypi.stackexchange.com/questions/33875/raspberry-pi-and-the-acs-acr1252u-usb-nfc-card-reader

import usb.core
import usb.util


# According to what I've read, full speed USB is 64 byte packet size.
packet_len = 64

# Packing a request.
# Packets are 64 bytes long, most of the commands are 4 bytes long. So up to 18
# can be batched into a packet. For example command with bytes [0x94, 0x0, 0x0, 0x0] is getting firmware id
def pack_request(*arguments):
    packet = [0x0] * packet_len
    i = 0
    for arg in arguments:
        packet[i] = arg
        i += 1
    #packet[0:4] = [0x94, 0x0, 0x0, 0x0] #get firmware id
    return ''.join([chr(c) for c in packet])


def main():
    #Updated for the ACS ACR1252U
    dev = usb.core.find(idVendor=0x72f, idProduct=0x8003)

    # was it found?
    if dev is None:
        raise ValueError('Device not found')

    try:
        dev.detach_kernel_driver(0)
    except: # this usually mean that kernel driver has already been dettached
        pass

    # ACS ACR1252U only has 1 configuration
    dev.set_configuration()

    # Interface 0: Dual Reader PICC. This is what we want
    # Interface 1: Dual Reader SAM
    try:
        dev.set_interface_altsetting(0)
    except usb.core.USBError:
        print 'Error setting interface!'
        pass

    # According to the API, to sound the buzzer we must send:
    #
    # Class: 0xe0
    # INS: 0x00
    # P1: 0x00
    # P2: 0x28
    # Lc: 0x01
    # DataIn (duration): 0xff (for 255 * 10ms = 2.55 seconds)
    raw = pack_request(0xe0, 0x00, 0x00, 0x28, 0x01, 0xff)

    #send the packet
    # Params are (endpoint, data, timeout)
    #
    # According to the script output:
    # ENDPOINT 0x01: Bulk OUT
    dev.write(endpoint=0x01, data=raw)
    #done


if __name__ == '__main__':
  main()