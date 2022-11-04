import React from "react";
import { Grid } from "@mui/material";
import Typography from "@mui/material/Typography";
import Breadcrumbs from "@mui/material/Breadcrumbs";
import Link from "next/link";
import _ from "lodash";
import styled from "@emotion/styled";

import { AppColor, Image } from "../../shared-components";
import * as Images from "./images";
import { Project, Tag } from "../../api/interfaces";

export interface ProjectProps {
  project: Project;
}

export default function Component({ project }: ProjectProps) {
  const imageProps = {
    width: 374 / 2,
    height: 684 / 2,
    alt: "something special",
  };

  const logoimageProps = { width: 150, height: 0, alt: "something special" };
  logoimageProps.height = imageProps.width * 0.5;

  return (
    <MainContainerDiv>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={3}>
          &nbsp;
        </Grid>
        <Grid item xs={12} xl={6}>
          <LogoHeaderDiv>
            <LogoImageDiv>
              <Image src={Images.LogoImage} {...logoimageProps} />
            </LogoImageDiv>
            <TitleHeading>Blog</TitleHeading>
          </LogoHeaderDiv>

          <ProjectsHeaderDiv>
            <Breadcrumbs aria-label="breadcrumb">
              <Link href="/">Home</Link>
              <Link href="/blog/projects">Projects</Link>
              <Typography color="textPrimary">{project.name}</Typography>
            </Breadcrumbs>
          </ProjectsHeaderDiv>

          <ProjectContainerDiv>
            <img src={project.imageUrl} alt="something special"></img>
            <Grid container justifyContent="center" alignItems="center">
              <Grid item xs={12} xl={4}>
                <p>trees planted</p>
                <TealParagraph>{project.treesPlanted}</TealParagraph>
              </Grid>
              <Grid item xs={12} xl={4}>
                <p>hectares restored</p>
                <OrangeParagraph>{project.hectaresRestored}</OrangeParagraph>
              </Grid>
              <Grid item xs={12} xl={4}>
                <p>since</p>
                <GreenParagraph>{project.yearSince}</GreenParagraph>
              </Grid>
              <Grid item xs={12} xl={12}>
                <h1>{project.title}</h1>
              </Grid>
              <Grid item xs={12} xl={6}>
                <p>{project.description}</p>
              </Grid>
              <Grid item xs={12} xl={6}>
                <Image src={Images.CountryMapImage} {...imageProps}></Image>
              </Grid>
              {showTags(project.tags)}
            </Grid>
          </ProjectContainerDiv>
        </Grid>
        <Grid item xs={12} xl={3}>
          &nbsp;
        </Grid>
      </Grid>
    </MainContainerDiv>
  );
}

function showTags(tags: Tag[] = []) {
  return (
    <React.Fragment>
      {tags.map((tag, index) => (
        <Grid item xs={12} xl={4} key={`tag-${index}`}>
          {renderImage(tag.title)}
          <p>{tag.title}</p>
          <p>{tag.subtitle}</p>
        </Grid>
      ))}
    </React.Fragment>
  );

  function renderImage(title: string) {
    const images = [
      { slug: "Partners", src: Images.PartnersImage },
      { slug: "Planting method", src: Images.PlantingMethodImage },
      { slug: "Planting season", src: Images.PlantingSeasonImage },
      { slug: "Main threats", src: Images.MainThreatsImage },
      { slug: "Wildlife protected", src: Images.WildlifeProtectedImage },
      { slug: "Challenges", src: Images.ChallengesImage },
    ];

    const foundImage = _.find(images, (x) =>
      x.slug.toLowerCase().includes(title.toLowerCase())
    );

    if (foundImage) {
      const imageProps = { width: 172, height: 161, alt: "something special" };

      return <Image src={foundImage.src} {...imageProps}></Image>;
    }
  }
}

// Styled Components

const MainContainerDiv = styled.div`
  padding: 100px 0px;
`;

const LogoHeaderDiv = styled.div`
  display: flex;
  justify-content: center;
  padding: 25px;
`;

const LogoImageDiv = styled.div`
  max-width: 100px;
`;

const TitleHeading = styled.h1`
  color: ${AppColor.Teal};
  text-transform: uppercase;
`;

const ProjectsHeaderDiv = styled.div`
  display: flex;
  justify-content: center;
`;

const ProjectContainerDiv = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;

  padding: 50px 0px;
  text-align: center;
`;

const TealParagraph = styled.p`
  background-color: ${AppColor.Teal};
  padding: 10px 0px;
`;

const OrangeParagraph = styled.p`
  background-color: orange;
  padding: 10px 0px;
`;

const GreenParagraph = styled.p`
  background-color: green;
  padding: 10px 0px;
`;
