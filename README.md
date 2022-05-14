# TextFilter
  
Installation guide:
       1- Install Microsoft Visual Studio 2019 community edition.
 
User Guide:
1-	Copy the project folder under source folder or the default folder of the Microsoft Visual Studio 2019.
2-	Open the project using Microsoft Visual Studio 2019.
3-	Open build tab then build the solution.
4-	Click the run button at the top of the page.
5-	Wait for the chrome page to show up then enter a text in the text box.
6-	Hit submit.
7-	The output page will display the sorted characters after removing the stop words.

Notes:
1-	I used a txt file that combines all the stop words in English, its name is “stop_words_english.txt”.
2-	I planned to use DataTable to sort the output but there is an issue there, so I sorted the characters from the code.
3-	 User submits a text in English or URL- done.
4-	Page filters out stop-words (e.g. ‘or’, ‘and’, ‘a’, ‘the’ etc)-- done
5-	Calculates number of occurrences on the page of each word- done.



