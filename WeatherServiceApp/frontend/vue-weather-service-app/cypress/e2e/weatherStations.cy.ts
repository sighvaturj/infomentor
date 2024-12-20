// https://on.cypress.io/api

describe('Weather Stations Dropdown', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('should display the correct station names and values in the dropdown', () => {
    const dropdownSelector = '.weather-stations select';

    // Expected station names (displayed in the dropdown)
    const expectedNames = [
      '-- Select a Station --',
      'Akrafjall',
      'Akureyri',
      'Reykjanesbraut',
      'Reykjavik',
      'Vestmannaeyjar',
    ];

    // Expected station IDs (used as values in the dropdown)
    const expectedIds = [
      '', // Placeholder option has an empty value
      '31572',
      '3471',
      '31363',
      '1475',
      '6015',
    ];

    // Check the dropdown displays the correct station names
    cy.get(dropdownSelector)
      .find('option')
      .then((options) => {
        const actualNames = [...options].map((option) => option.text.trim());
        expect(actualNames).to.deep.equal(expectedNames);
      });

    // Check the dropdown has the correct values for each option
    cy.get(dropdownSelector)
      .find('option')
      .then((options) => {
        const actualValues = [...options].map((option) => option.value.trim());
        expect(actualValues).to.deep.equal(expectedIds);
      });
  });

  it('should allow the user to select a weather station', () => {
    cy.get('.weather-stations select')
      .select('Akrafjall') // Select by visible text
      .should('have.value', '31572'); // Ensure the value is correct
  });
});
