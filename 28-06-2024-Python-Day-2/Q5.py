# luhn_check.py

def luhn_check(card_number):
    def digits_of(n):
        return [int(d) for d in str(n)]
    
    digits = digits_of(card_number)
    odd_digits = digits[-1::-2]
    even_digits = digits[-2::-2]
    checksum = sum(odd_digits)
    
    for d in even_digits:
        checksum += sum(digits_of(d * 2))
    
    return checksum % 10 == 0

card_number = "4532015112830366"
if luhn_check(card_number):
    print(f"The card number {card_number} is valid.")
else:
    print(f"The card number {card_number} is invalid.")
