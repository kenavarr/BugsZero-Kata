Feature: WinGame
	En tant que joueur de Trivia
	Je souhaite pouvoir gagner une partie 
	Afin de montrer à mes amis que je suis le meilleur

Background: 
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |

Scenario: Un joueur gagne la partie quand il acquiert son 6ème point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 5 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' a gagné la partie

Scenario: Un joueur ne gagne pas la partie quand il acquiert son 1er point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 0 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' n'a pas gagné la partie

Scenario: Un joueur ne gagne pas la partie quand il acquiert son 2ème point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 1 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' n'a pas gagné la partie

Scenario: Un joueur ne gagne pas la partie quand il acquiert son 3ème point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 2 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' n'a pas gagné la partie

Scenario: Un joueur ne gagne pas la partie quand il acquiert son 4ème point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 3 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' n'a pas gagné la partie

Scenario: Un joueur ne gagne pas la partie quand il acquiert son 5ème point
	Given 'Sue' doit répondre à une question
	And 'Sue' a 4 points
	When 'Sue' gagne un nouveau point
	Then 'Sue' n'a pas gagné la partie