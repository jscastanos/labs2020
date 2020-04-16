# Error Handling Challenge

## Task

- Stop the errors! If an exception occurs in the MakePayment method, catch it and print “Payment skipped for payment with 4 items” (or whatever the number is). However, the method properly returns a null one time. Fix that error (don’t just catch it) and print “Null value for item 4” instead.  
- **BONUS** - Handle the different errors differently. If you get an IndexOutOfRange exception, print “Skipped invalid record”. If it is a FormatException and the number of items is not 5, print “Formatting Issue”. For everything else, print the standard error.  
- **BONUS** - If an exception has an InnerException, print the Message of the InnerException at the end of whatever message is being displayed.

## Output

![output](https://github.com/jscastanos/TCWeeklyChallenges/blob/master/3%20-%20Error%20Handling/output.JPG)

## Author's Notes

- The challenge is a bit tricky and I'm not sure if I what I did is a fixed in the NullReferenceException part.

## Sources

- [Challenge Video](https://www.youtube.com/watch?v=T7-zigMDfEQ&list=PLLWMQd6PeGY1VcJGocm1wwtFCZUrh2sc9&index=3)
