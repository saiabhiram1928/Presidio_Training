# Solution 7: Take 10 numbers and find the average of all the prime numbers in the collection

def is_prime(num):
    if num <= 1:
        return False
    for i in range(2, int(num ** 0.5) + 1):
        if num % i == 0:
            return False
    return True

numbers = []
for _ in range(10):
    numbers.append(int(input("Enter a number: ")))

prime_numbers = [num for num in numbers if is_prime(num)]
if prime_numbers:
    average = sum(prime_numbers) / len(prime_numbers)
    print(f"The average of the prime numbers is {average}.")
else:
    print("No prime numbers were entered.")
