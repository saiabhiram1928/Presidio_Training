# Solution 10: Print a pyramid of stars for the number of rows specified
rows = int(input("Enter the number of rows: "))

for i in range(rows):
    print(' ' * (rows - i - 1) + '*' * (2 * i + 1))
