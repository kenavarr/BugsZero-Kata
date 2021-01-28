Feature: RollDiceToSwichPosition
	En tant que joueur de Trivia
	Je souhaite pouvoir lancer un dé
	Afin de me déplacer sur le plateau
	Et de changer de catégorie de questions

Background: 
	Given Les joueurs de Trivia
	| Nom  |
	| Chet |
	| Pat  |
	| Sue  |

Scenario: Un joueur qui n'est pas en prison change de position en faisant 1 à son jet de dé
	Given 'Pat' est le joueur de ce tour
	When 'Pat' fait 1 à son jet de dé
	Then 'Pat' arrive à la position 1 du plateau

Scenario: Un joueur en position 10 du plateau, qui n'est pas en prison, change de position en faisant 5 à son jet de dé
	Given 'Pat' est le joueur de ce tour
	And 'Pat' est en position 10
	When 'Pat' fait 5 à son jet de dé
	Then 'Pat' arrive à la position 3 du plateau

Scenario: Un joueur qui est en prison ne change pas de position en faisant 2 à son jet de dé
	Given 'Chet' est le joueur de ce tour
	And 'Chet' est en prison
	When 'Chet' fait 2 à son jet de dé
	Then 'Chet' ne change pas de position

Scenario: Un joueur qui est en prison ne change pas de position en faisant 4 à son jet de dé
	Given 'Chet' est le joueur de ce tour
	And 'Chet' est en prison
	When 'Chet' fait 4 à son jet de dé
	Then 'Chet' ne change pas de position

Scenario: Un joueur qui est en prison ne change pas de position en faisant 6 à son jet de dé
	Given 'Chet' est le joueur de ce tour
	And 'Chet' est en prison
	When 'Chet' fait 6 à son jet de dé
	Then 'Chet' ne change pas de position

Scenario: Un joueur qui est en prison change de position en faisant 1 à son jet de dé
	Given 'Sue' est le joueur de ce tour
	And 'Sue' est en prison
	When 'Sue' fait 1 à son jet de dé
	Then 'Sue' arrive à la position 1 du plateau

Scenario: Un joueur qui est en prison change de position en faisant 3 à son jet de dé
	Given 'Sue' est le joueur de ce tour
	And 'Sue' est en prison
	When 'Sue' fait 3 à son jet de dé
	Then 'Sue' arrive à la position 3 du plateau

Scenario: Un joueur qui est en prison change de position en faisant 5 à son jet de dé
	Given 'Sue' est le joueur de ce tour
	And 'Sue' est en prison
	When 'Sue' fait 5 à son jet de dé
	Then 'Sue' arrive à la position 5 du plateau