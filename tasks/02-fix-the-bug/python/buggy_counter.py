# buggy_counter.py

import threading
import time

_current = 0

def next_id():
    """Returns a unique ID, incrementing the global counter."""
    global _current
    value = _current
    time.sleep(0)
    _current += 1
    return value
