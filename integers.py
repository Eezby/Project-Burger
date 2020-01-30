class Integers:

    def __init__(self, num):
        self.num = num

    
    def get_num(self):
        return self.num

def main():
    num_int = Integers(5)

    print("Get: {}".format(num_int.get_num()))

def if __name__ == "__main__":
    main()