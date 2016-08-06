class Config:
    gateId = 0
    route = ""
    port = "COM3"
    def __init__(self, gateId, route):
        self.gateId=gateId
        self.route=route
