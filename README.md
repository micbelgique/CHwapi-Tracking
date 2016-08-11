# CHwapi Tracking

## Common tools

- [Git](https://git-scm.com/)

## Description

Create a web application allowing to track packages inside Chwapi hospital via RFID gate.  Create package, objects.

## DevCamp2016-Muffin 'Suicidal' Bandits

+ Alexandre De Coster
+ [Christof Hullaert](https://github.com/cHullaert)
+ [Alexandre Devaux](https://githbub.com/overworks-be)
+ Laurent Procureur

## Back End

Web API of the application database and listener of the gates.

### Technologies
+ Web API ASP.NET 4.6.1
+ Entity Framework 6
+ SQL Express 2014

1. Clone Visual Studio project
2. Setup project with your options (IIS) 
3. Create database from Entity Framework
4. Build project and publish it in IIS

## Front End

This project was generated with the [Angular Full-Stack Generator](https://github.com/DaftMonk/generator-angular-fullstack) version 3.7.6.

### Getting Started

#### Techno

- [Node.js and npm](nodejs.org) Node ^4.2.3, npm ^2.14.7
- [Bower](bower.io) (`npm install --global bower`)
- [Ruby](https://www.ruby-lang.org) and then `gem install sass`
- [Gulp](http://gulpjs.com/) (`npm install --global gulp`)
- [MongoDB](https://www.mongodb.org/) - Keep a running daemon with `mongod`  (only for development use)

#### Developing

1. Run `npm install` to install server dependencies.
2. Run `bower install` to install front-end dependencies.
3. Run `mongod` in a separate shell to keep an instance of the MongoDB Daemon running
4. Run `gulp serve` to start the development server. It should automatically open the client in your browser when ready.

### Build & development

Run `grunt build` for building and `grunt serve` for preview.

### Testing

Running `npm test` will run the unit tests with karma.

## RFID Gate

Gate RFID to scan and track package of goods.  The gate is message agnostic since it's the backend who specify message type.

### Hardware

- [Arduino](https://www.arduino.cc)
- [Raspberry PI 3](https://www.raspberrypi.org/products/raspberry-pi-3-model-b/)
- [PN532 (RFID Controller)](https://www.adafruit.com/product/789)

### Methodology

The PN532 scans the card and retrieve information of package on the card and communicate it in the arduino.  The Arduino via the Serial Port pass the message to the raspberry.
The raspberry can then sends via http the message to the backend.  In the current example, we use the fourth block of the rfid card.

### Technologies

- Arduino Language
- Raspbian 
- Python

### Deployment

- Deploy sketch on the arduino (via arduino ide)
- install [raspbian](https://www.raspberrypi.org/downloads/raspbian/) on the raspberry
- install [pySerial](https://pypi.python.org/pypi/pyserial/2.7) on raspberry 
- install [requests](http://docs.python-requests.org/en/master/) package on raspberry

### Usage

- Launch main.py --serial:*portname* --route:*route*
	-- *portname*: name of the serial portname
	-- *route*; route to the backend
- scan cards.

### Images

<div class="container">
  <div class="row">
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture1.png" alt="Capture1"/></div>
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture2.png" alt="Capture2"/></div>
  </div>
  <div class="row">
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture3.png" alt="Capture3"/></div>
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture4.png" alt="Capture4"/></div>
  </div>
  <div class="row">
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture5.png" alt="Capture5"/></div>
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture6.png" alt="Capture6"/></div>
  </div>
  <div class="row">
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture7.png" alt="Capture7"/></div>
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture8.png" alt="Capture8"/></div>
  </div>
  <div class="row">
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture9.png" alt="Capture9"/></div>
    <div class="col-md-6"><img src="https://github.com/micbelgique/DevCamp2016-Team9/blob/master/FrontEnd/client/assets/images/Capture10.png" alt="Capture10"/></div>
  </div>
</div>
