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
        print(line)
        try:
            parts = line.strip().split('|')
            inputParts = [int(parts[0]), int(parts[1]), str(parts[2]), str(parts[3])]
            return inputParts
        except Exception as err:
            print(f"Parse Hatası: {err}")
            return None
