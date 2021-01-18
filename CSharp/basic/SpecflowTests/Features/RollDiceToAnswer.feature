Feature: RollDiceToAnswer
	En tant que joueur de Trivia
	Je souhaite pouvoir lancer un dé
	Afin de répondre à une question
	Et de marquer un point

Background: 
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |

Scenario: Un joueur donne la bonne réponse à une question en faisant 1 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 1 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 2 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 2 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 3 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 3 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 4 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 4 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 5 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 5 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 6 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 6 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 8 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 8 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la bonne réponse à une question en faisant 9 à son jet de dé
	Given 'Chet' doit répondre à une question
	When 'Chet' fait 9 à son jet de dé
	Then 'Chet' marque un point

Scenario: Un joueur donne la mauvaise réponse à une question en faisant 7 à son jet de dé
	Given 'Pat' doit répondre à une question
	When 'Pat' fait 7 à son jet de dé
	Then 'Pat' ne marque pas de point
	And 'Pat' va en prison