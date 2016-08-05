import json

class Track:
    message=""
    gateId=0

    def __init__(self, message, gateId):
        self.gateId=gateId
        self.message=message

class TrackEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, Track):
            return {"gateId": obj.gateId, "message": obj.message}
        # Let the base class default method raise the TypeError
        return json.JSONEncoder.default(self, obj)