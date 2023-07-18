// Behavior Driven Development - Dan North
// When write tests for a component, want to describe it in various different modes
// If building calculator, want to describe that it can do addition. It should be able to take 2+2 and produce 4.


import { TodoListItemModel } from '../../models';
import { ListComponent } from './list.component';

 

describe(ListComponent.name, () => {
  describe('Utopian State', () => {
    let utopianList: TodoListItemModel[] = [
      {
        id: 'a',
        description: 'Buy More Beer',
        status: 'Later',
      },
      {
        id: 'b',
        description: 'Mow the Lawn',
        status: 'Now',
      },
      {
        id: 'c',
        description: 'Pet The Cat',
        status: 'Waiting',
      },
      { id: 'd', description: 'Fix Lighting', status: 'Completed' },
    ];
    beforeEach(() =>
      cy.mount(ListComponent, {
        componentProperties: {
          list: utopianList,
        },
      })
    );

 

    it('Has Four Items', () => {
      cy.get('li').should('have.length', 4);
    });

 

    it('The First Item is For Later', () => {
      cy.get('li')
        .first()
        .find('button')
        .should('contain.text', utopianList[0].status);
    });
    it('The First Item is For Later', () => {
      cy.get('li')
        .eq(1)
        .find('button')
        .should('contain.text', utopianList[1].status);
    });
    it('Should not display an alert with a message', () => {
      cy.get('[data-testid="empty-list-alert"]').should('not.exist');
    });
  });
  describe('Empty List', () => {
    beforeEach(() =>
      cy.mount(ListComponent, {
        componentProperties: {
          list: [],
        },
      })
    );

 

    it('Should not display the list', () => {
      cy.get('[data-testid="shopping-list"]').should('not.exist');
    });

 

    it('Should display an alert with a message', () => {
      cy.get('[data-testid="empty-list-alert"]')
        .should('exist')
        .should('have.text', 'No Items in Your List');
    });
  });
});