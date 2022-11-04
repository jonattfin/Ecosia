import { Button, Grid } from "@mui/material";
import Link from "next/link";
import styled from "@emotion/styled";
import TwitterIcon from "@mui/icons-material/Twitter";
import FacebookIcon from "@mui/icons-material/Facebook";
import PinterestIcon from "@mui/icons-material/Pinterest";

import { ITranslationFunc } from "../../../helpers";
import { useState } from "react";
import { Project } from "../../../api/interfaces";

export interface ProjectsProps {
  projects: Project[];
  t: ITranslationFunc;
}

export default function Component({ projects, t }: ProjectsProps) {
  const [shownId, setShownId] = useState(0);

  return (
    <Grid container spacing={2}>
      <Grid item xs={12} xl={12}>
        <ProjectsDescriptionDiv>{t("treePlanting")}</ProjectsDescriptionDiv>
      </Grid>
      {projects.map((project) => (
        <Grid
          item
          xs={12}
          lg={6}
          xl={4}
          key={project.id}
          onMouseEnter={() => setShownId(project.id)}
          onMouseLeave={() => setShownId(0)}
        >
          <div>
            <ProjectImg src={project.imageUrl}></ProjectImg>
            <TitleContainerDiv>
              <TitleParagraph>{project.scope}</TitleParagraph>
              {shownId === project.id && showMediaLinks(project)}
            </TitleContainerDiv>
            <SubtitleParagraph>{project.name}</SubtitleParagraph>
            <p>{project.desc}</p>
            <Link href={`/project/${project.id}`}>
              <a>
                <Button size="small" color="secondary">
                  View
                </Button>
              </a>
            </Link>
          </div>
        </Grid>
      ))}
    </Grid>
  );
}

function showMediaLinks(project: Project) {
  return (
    <div>
      <a
        target="_blank"
        rel="noreferrer"
        href={`https://twitter.com/intent/tweet?text=${project.name}`}
      >
        <TwitterIcon color="primary" />
      </a>

      <a target="_blank" href="https://www.facebook.com" rel="noreferrer">
        <FacebookIcon color="primary" />
      </a>

      <a target="_blank" href="https://pinterest.com/" rel="noreferrer">
        <PinterestIcon color="primary" />
      </a>
    </div>
  );
}

// Styled Components

const ProjectsDescriptionDiv = styled.div`
  display: flex;
  justify-content: center;
  padding: 50px;
  border: 1px dashed grey;
`;

const ProjectImg = styled.img`
  max-width: 100%;
`;

const TitleContainerDiv = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
`;

const TitleParagraph = styled.p`
  text-transform: uppercase;
  border-left: 5px solid teal;
  padding: 5px;
`;

const SubtitleParagraph = styled.p`
  font-size: larger;
`;
