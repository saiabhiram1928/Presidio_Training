# prime_numbers.py

def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

def prime_numbers_up_to(n):
    primes = []
    for i in range(2, n + 1):
        if is_prime(i):
            primes.append(i)
    return primes

given_number = 30
print(f"List of prime numbers up to {given_number}: {prime_numbers_up_to(given_number)}")
