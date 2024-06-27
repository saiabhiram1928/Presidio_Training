# Solution 5: Add validation to the entered name, age, date of birth, and phone, then print details in proper format

def is_valid_name(name):
    return name.isalpha()

def is_valid_age(age):
    return age.isdigit() and 0 < int(age) < 120

def is_valid_dob(dob):
    try:
        day, month, year = map(int, dob.split('-'))
        return 1 <= day <= 31 and 1 <= month <= 12 and 1900 <= year <= 2100
    except ValueError:
        return False

def is_valid_phone(phone):
    return phone.isdigit() and len(phone) == 10

name = input("Enter your name: ")
while not is_valid_name(name):
    print("Invalid name. Please enter a valid name.")
    name = input("Enter your name: ")

age = input("Enter your age: ")
while not is_valid_age(age):
    print("Invalid age. Please enter a valid age.")
    age = input("Enter your age: ")

dob = input("Enter your date of birth (DD-MM-YYYY): ")
while not is_valid_dob(dob):
    print("Invalid date of birth. Please enter in DD-MM-YYYY format.")
    dob = input("Enter your date of birth (DD-MM-YYYY): ")

phone = input("Enter your phone number: ")
while not is_valid_phone(phone):
    print("Invalid phone number. Please enter a 10-digit phone number.")
    phone = input("Enter your phone number: ")

print(f"Name: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")
