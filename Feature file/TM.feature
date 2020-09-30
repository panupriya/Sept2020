Feature: TM
	
Background: Navigation to TM Page
	Given I navigate to the TM

@mytag
Scenario: Verify the TM is created


	Given I navigate to create new page

Scenario Outline: Verify multiple TM creation
When I create entry using code : '<code>' and desc: '<desc>'
Then I am able to verify entry with code : '<code>'
Examples: 
| code       | desc      |
| September1 | SeptDesc1 |
| September2 | SeptDesc2 |

Scenario: Verify usage of Data Tables
When I create entries using values from table :
| code       | desc      |
| September3 | Sept3Desc |
| September4 | Sept4Desc |
