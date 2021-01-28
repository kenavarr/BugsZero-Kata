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
	Given Un joueur doit répondre à une question

Scenario: Un joueur donne la bonne réponse à une question
	When Le joueur donne la bonne réponse
	Then Le joueur marque un point

Scenario: Un joueur donne la mauvaise réponse à une question
	When Le joueur donne la mauvaise réponse
	Then Le joueur ne marque pas de point
	And Le joueur va en prison