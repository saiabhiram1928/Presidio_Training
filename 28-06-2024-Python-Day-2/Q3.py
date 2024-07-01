# sort_players.py

def sort_players(players):
    # Sort players first by score in descending order, then by name in ascending order
    sorted_players = sorted(players, key=lambda x: (-x['score'], x['name']))
    return sorted_players[:10]

players = [
    {'name': 'Alice', 'score': 150},
    {'name': 'Bob', 'score': 200},
    {'name': 'Charlie', 'score': 100},
    {'name': 'David', 'score': 200},
    {'name': 'Eve', 'score': 50},
    {'name': 'Frank', 'score': 120},
    {'name': 'Grace', 'score': 220},
    {'name': 'Heidi', 'score': 110},
    {'name': 'Ivan', 'score': 130},
    {'name': 'Judy', 'score': 140},
    {'name': 'Mallory', 'score': 160},
    {'name': 'Niaj', 'score': 170}
]

top_players = sort_players(players)
print("Top 10 players:")
for player in top_players:
    print(f"Name: {player['name']}, Score: {player['score']}")
