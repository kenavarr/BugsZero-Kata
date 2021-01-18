Feature: Answer
	En tant que joueur de Trivia
	Je souhaite pouvoir répondre à une question 
	Afin de gagner des points

Background: 
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |

Scenario: Un joueur donne la bonne réponse à une question
	Given 'Chet' doit répondre à une question
	When 'Chet' donne la bonne réponse
	Then 'Chet' marque un point

Scenario: Un joueur donne la mauvaise réponse à une question
	Given 'Pat' doit répondre à une question
	When 'Pat' donne la mauvaise réponse
	Then 'Pat' ne marque pas de point
	And 'Pat' va en prison