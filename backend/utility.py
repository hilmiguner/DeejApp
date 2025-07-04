import json

class Utility:
    @staticmethod
    def normalize(value, out_min=0.0, out_max=1.0, dead_zone_low=5, dead_zone_high=1018):
        if value <= dead_zone_low:
            return out_min
        elif value >= dead_zone_high:
            return out_max
        else:
            return (value - dead_zone_low) * (out_max - out_min) / (dead_zone_high - dead_zone_low) + out_min

    @staticmethod
    def parseInputData(line: str):
        try:
            parts = line.strip().split('|')
            inputParts = [int(parts[0]), int(parts[1]), str(parts[2]), str(parts[3])]
            return inputParts
        except Exception as err:
            if "invalid literal for int() with base 10" in str(err):
                pass
            else:
                Utility.log(f"[Parsing Data] Error: {err}")
            return None
        
    @staticmethod
    def createBroadcastJson(slider1, slider2, button1, button2):
        return json.dumps({
            "masterVolume": slider1,
            "micVolume": slider2,
            "masterMute": button1,
            "micMute": button2
        })

    @staticmethod
    def log(text):
        print(text, flush=True)

