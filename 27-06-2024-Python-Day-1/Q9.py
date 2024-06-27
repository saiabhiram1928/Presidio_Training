# Solution 9: Find all permutations of a given string
from itertools import permutations

input_string = input("Enter a string: ")
permutations_list = [''.join(p) for p in permutations(input_string)]

print("All permutations of the given string are:")
for perm in permutations_list:
    print(perm)
