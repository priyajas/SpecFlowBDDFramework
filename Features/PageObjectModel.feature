Feature: PageObjectModel

Search repository in Github and Verify Results are Correct

@GithubSearch
Scenario:  GitHubSearchRepositoryResultValidation
	Given Enter the Github Search URL
	When Search for the Android Repository in Github
    And Verify Search Results contains Android
	And Navigate to Repository
	Then Verify title of the page


@GithubFilterList
Scenario: GitHubSearchRepositoryFilterOptionsValidation
		Given Enter the Github Search URL
		When Search for the Android Repository in Github
		Then Verify Search Results Filter Contains Options
		  | Code          |
		  | Repositories  |
		  | Issues        |
		  | Pull requests |
		  | Marketplace   |
		  | Discussions   |
		  | Users         |
		  | Commits       |
		  | Packages      |
		  | Wikis         |
		  | Topics        |

