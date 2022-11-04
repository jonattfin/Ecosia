import { ComponentStory } from "@storybook/react";
import _ from 'lodash';
import { loremIpsum } from "lorem-ipsum";
import { Project } from "../../api/interfaces";

import ProjectComponent from "./project-component";

export default function Index() {
  return <div></div>;
}

const ProjectPageTemplate: ComponentStory<typeof ProjectComponent> = (args) => (
  <ProjectComponent {...args} />
);

export const SearchComponent = ProjectPageTemplate.bind({});
SearchComponent.args = {
  ...getProjectAndTags(),
};

function getProjectAndTags() {
  const project: Project = {
    id: 1,
    name: "name",
    description: loremIpsum({count: 10}),
    imageUrl:
      "https://blog.ecosia.org/content/images/size/w1200/2021/08/Thailand_header.png",
    scope: "scope",
    title: loremIpsum(),
    treesPlanted: _.random(100, 1000).toString(),
    hectaresRestored: _.random(100, 1000).toString(),
    yearSince: _.random(2015, 2022),
    tags: [],
  };
  return { project, tags: [] };
}



