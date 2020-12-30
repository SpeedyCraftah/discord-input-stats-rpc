from pynput.keyboard import Listener
import threading

def __run__(on_press):
    with Listener(on_press=on_press) as listener:
        listener.join()

def register_keys(on_press):
    threading.Thread(target=__run__, args=(on_press,)).start()
    print("Key tracker thread armed.")