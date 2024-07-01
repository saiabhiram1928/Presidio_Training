# longest_substring.py

def longest_substring_without_repeating_characters(s):
    char_index_map = {}
    longest = 0
    start = 0

    for i, char in enumerate(s):
        if char in char_index_map and char_index_map[char] >= start:
            start = char_index_map[char] + 1
        char_index_map[char] = i
        longest = max(longest, i - start + 1)

    return longest


input_string = "abcabcbb"
print(f"The length of the longest substring without repeating characters is: {longest_substring_without_repeating_characters(input_string)}")
