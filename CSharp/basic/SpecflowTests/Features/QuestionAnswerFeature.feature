Feature: QuestionAnswerFeature
	En tant que joueur de Trivia
	Je souhaite pouvoir poser une question à un autre joueur 
	Afin qu'il puisse répondre à celle-ci

Scenario: Un joueur pose une question à un autre joueur qui donne la bonne réponse.
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |
	And La question "Qui sont les cofondateurs de Microsoft en 1975 ?"
	When Le joueur "Chet" pose la question "Qui sont les cofondateurs de Microsoft en 1975 ?" au joueur "Pat"
	And Le joueur "Pat" donne la bonne réponse à la question "Qui sont les cofondateurs de Microsoft en 1975 ?"
	Then Le joueur "Pat" marque 1 point supplémentaire

Scenario: Un joueur pose une question à un autre joueur qui donne la mauvaise réponse.
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |
	And La question "Qui sont les cofondateurs de Microsoft en 1975 ?"
	When Le joueur "Chet" pose la question "Qui sont les cofondateurs de Microsoft en 1975 ?" au joueur "Pat"
	And Le joueur "Pat" donne la mauvaise réponse à la question "Qui sont les cofondateurs de Microsoft en 1975 ?"
	Then Le joueur "Pat" ne marque pas de point
	And Le joueur "Pat" va en prison