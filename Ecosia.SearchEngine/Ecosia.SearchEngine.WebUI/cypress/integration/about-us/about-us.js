/// <reference types="cypress" />

import { Given, Then } from 'cypress-cucumber-preprocessor/steps'

Given('The user opens the about us page', () => {
  cy.visit(`http://localhost:3000/about-us`)
})

describe("The banner section is shown", () => {
  Then('The banner section title and add ecosia button are shown', () => {

    cy.getBySel('banner-title')
      .should('be.visible')
      .should('have.text', "We believe in everyone's power to do good")

    cy.getBySel('add-ecosia-button')
      .should('be.visible')
      .should('have.text', 'Add Ecosia to Firefox')
  });
});
