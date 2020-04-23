# Refactoring Challenge

## Task

- Refactor the code to only do things once (DRY). Specifically, look at how to make the database calls once instead of multiple times in each user interface.
- **BONUS** - Remove all references to data access (directly) from the user interface and reduce the data access code down to two methods that can be called in one line each, regardless of which SQL call is being made or what the data is coming in or going out.

## Output

- Compare 056ac2280d58dce0f612eff1e0530d3a5bb5b6ad (Unchanged) to 20b97a653f191a16e394959299f6cfc51bb4f21c (Refactored)

## Notes

- I made it as DRY as possible 😉
- For Bonus Challenge, I created a separate Class Library for Data Access Layer and Models.

## Sources

- [Challenge Video](https://www.youtube.com/watch?v=0OTgq9nFQjI&list=PLLWMQd6PeGY1VcJGocm1wwtFCZUrh2sc9&index=4)
