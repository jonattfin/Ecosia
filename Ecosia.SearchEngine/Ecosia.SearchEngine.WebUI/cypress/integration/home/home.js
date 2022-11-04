/// <reference types="cypress" />

import { Given, When, Then } from "cypress-cucumber-preprocessor/steps";

Given("The user opens the home page", () => {
  cy.visit(`http://localhost:3000/`);
});

describe("User types for a query in the search input", () => {
  When("The user search for the query in the search input", () => {
    const q = "hello";

    cy.getBySel("searchInput")
      .wait(100)
      .type(q)
      .should("contain.value", q)

    cy.getBySel("searchList")
      .wait(100)
      .first()
      .click();
  });

  Then("The user is redirected to the results page", () => {
    cy.url().should("contain", `http://localhost:3000/search/hello`);
  });
});

describe("The countries section is shown", () => {
  Then("The countries section title and subtitle are shown", () => {
    cy.getBySel("countries-title")
      .should("be.visible")
      .should("have.text", "Where are your trees being planted?");

    cy.getBySel("countries-subtitle")
      .should("be.visible")
      .should(
        "have.text",
        "We plant in 30+ countries with local organizations"
      );
  });
});

describe("The map section is shown", () => {
  Then("The map section title and discover our project link are shown", () => {
    cy.getBySel("map-title")
      .should("be.visible")
      .should("have.text", "Trees planted by Ecosia users");

    cy.getBySel("discover-projects")
      .should("be.visible")
      .should("contain.text", "Discover our projects");
  });
});

describe("The financial section is shown", () => {
  Then(
    "The financial section title and explore financial reports are shown",
    () => {
      cy.getBySel("reports-title")
        .should("be.visible")
        .should("have.text", "Monthly financial reports");

      cy.getBySel("explore-reports")
        .should("be.visible")
        .should("contain.text", "Explore our financial reports");
    }
  );
});

describe("The join section is shown", () => {
  Then("The join section title and share ecosia button are shown", () => {
    cy.getBySel("join-us-title")
      .should("be.visible")
      .should("have.text", "Join 15 million people who already use Ecosia");

    cy.getBySel("share-ecosia").should("be.visible");
  });
});
