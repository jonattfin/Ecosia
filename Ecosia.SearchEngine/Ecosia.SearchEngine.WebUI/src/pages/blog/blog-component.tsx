import { Grid } from "@mui/material";
import React, { Fragment, SyntheticEvent, useState } from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import styled from "@emotion/styled";

import { AppColor, Image } from "../../shared-components";
import * as Images from "./components/images";
import { Language } from "../../providers/context";
import { ITranslationFunc, withTranslations } from "../../helpers";
import { ProjectsComponent, ReportsComponent } from "./components";
import Link from "next/link";
import { Project, ReportData } from "../../api/interfaces";

export interface BlogProps {
  projects: Project[];
  reports: ReportData[];
  language: string;
  id: number;
}

interface BlogPropsWithTranslation extends BlogProps {
  t: ITranslationFunc;
}

const Component = ({ projects, t, reports, id }: BlogPropsWithTranslation) => {
  const [value, setValue] = useState(id);

  const handleChange = (_event: SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const imageProps = { width: 150, height: 0, alt: "something special" };
  imageProps.height = imageProps.width * 0.5;

  return (
    <MainContainer>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={3}>
          &nbsp;
        </Grid>
        <Grid item xs={12} xl={6}>
          <LogoHeaderDiv>
            <LogoImageDiv>
              <Link href={`/`}>
                <a>
                  <Image src={Images.LogoImage} {...imageProps} />
                </a>
              </Link>
            </LogoImageDiv>
            <TitleHeader>Blog</TitleHeader>
          </LogoHeaderDiv>

          <ProjectsHeaderDiv>
            <Tabs
              value={value}
              onChange={handleChange}
              textColor="secondary"
              indicatorColor="secondary"
            >
              <Tab value={0} label="Trees" />
              <Tab value={1} label="Money" />
            </Tabs>
          </ProjectsHeaderDiv>
          <SeparatorDiv />
          <TabPanel index={0} value={value}>
            <ProjectsComponent {...{ projects, t }} />
          </TabPanel>
          <TabPanel index={1} value={value}>
            <ReportsComponent
              {...{
                t,
                reports,
              }}
            />
          </TabPanel>
        </Grid>
        <Grid item xs={12} xl={3}>
          &nbsp;
        </Grid>
      </Grid>
    </MainContainer>
  );
};

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index } = props;
  if (value !== index) return <Fragment />;

  return <div>{children}</div>;
}

// Styled Components

const MainContainer = styled.div`
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

const TitleHeader = styled.h1`
  color: ${AppColor.Teal};
  text-transform: uppercase;
`;

const ProjectsHeaderDiv = styled.div`
  display: flex;
  justify-content: center;
`;

const SeparatorDiv = styled.div`
  margin: 50px 0px;
`;

// translations

const translations = {
  [Language.English]: {
    title: `Let's be clear about the numbers`,
    treePlanting: `Tree planting at Ecosia, we plant trees where they're needed
    most. Browse through our tree-planting portfolio to learn where the
    trees stand, which species we plant, and what their impact is. And
    much more!`,
    aboutTransparency: `We're all about transparency. That's why we publish monthly financial
    reports. They keep you in the loop about our latest tree-planting
    projects, how much money we made from your searches, and how we spent
    it. Ecosia is a not-for-profit business. We don't pay out dividends
    and cannot be bought. That way, we're able to use 100% of our profits
    for the planet. Keep in mind that it takes six weeks to process the
    month's payments.`,
    totalIncome: "Total income this month.",
    treesFinanced: "Trees financed this month.",
  },
  [Language.French]: {},
};

export default withTranslations(translations)(Component);
