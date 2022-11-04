import _ from "lodash";

import { withLanguageControls } from "../../helpers";
import BlogComponent, { BlogProps } from "./blog-component";

export default function Index() {
  return <div></div>;
}

const props: BlogProps = {
  id: 1,
  projects: [],
  reports: getReports(),
  language: "",
};

export const BlogIndex = withLanguageControls(BlogComponent, props);

function getReports() {
  const year = 2022;
  const months = ["April", "March", "February"];

  const investments = [
    "trees",
    "green investments",
    "taxes and social security",
    "spreading the word",
    "operational costs",
  ];
  const countries = [
    "brazil",
    "kenya",
    "tanzania",
    "rwanda",
    "mexico",
    "thailand",
  ];

  return months.map((month) => {
    return {
      month: `${month}`,
      year,
      investments: investments.map((investment) => ({
        name: investment,
        value: _.random(100, 1000),
      })),
      countries: countries.map((country) => ({
        name: country,
        value: _.random(100, 1000),
      })),
    };
  });
}
