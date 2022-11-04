import { Grid } from "@mui/material";
import ChevronRightIcon from "@mui/icons-material/ChevronRight";
import Link from "next/link";
import styled from "@emotion/styled";
import {
  AppColor,
  LinkDiv,
  MainTitleDiv,
  MainSubtitleKickDiv,
} from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";

export interface MapComponentProps {
  counter: number;
  t: ITranslationFunc;
}

const Component = ({ counter, t }: MapComponentProps) => {
  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <MainTitleDiv data-test="map-title">{t("treesPlanted")}</MainTitleDiv>
          <MainSubtitleKickDiv>{counter}</MainSubtitleKickDiv>
        </Grid>
        <Grid item xs={12} xl={3}>
          <TitleDiv>15 Million</TitleDiv>
          <ContentDiv>{t("peopleUsing")}</ContentDiv>
        </Grid>
        <Grid item xs={12} xl={3}>
          <TitleDiv>500+</TitleDiv>
          <ContentDiv>{t("nativeSpecies")}</ContentDiv>
        </Grid>
        <Grid item xs={12} xl={3}>
          <TitleDiv>30+</TitleDiv>
          <ContentDiv>{t("countries")}</ContentDiv>
        </Grid>
        <Grid item xs={12} xl={3}>
          <TitleDiv>60+</TitleDiv>
          <ContentDiv>{t("activeProjects")}</ContentDiv>
        </Grid>
        <Grid item xs={12} xl={12}>
          <LinkDiv>
            <Link href="/blog/projects">
              <a data-test="discover-projects">
                {t("discover")} <ChevronRightIcon fontSize="small" />
              </a>
            </Link>
          </LinkDiv>
        </Grid>
        <Grid item xs={12} xl={12}>
          &nbsp;
        </Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const TitleDiv = styled.div`
  font-size: x-large;
  padding-left: 20px;
  border-left: 5px solid ${AppColor.Teal};
`;

const ContentDiv = styled.div`
  padding-left: 20px;
  border-left: 5px solid ${AppColor.Teal};
`;

// translations

const translations = {
  [Language.English]: {
    treesPlanted: "Trees planted by Ecosia users",
    peopleUsing: "People using Ecosia",
    nativeSpecies: "Native species",
    countries: "Countries",
    activeProjects: "Active projects",
    discover: "Discover our projects",
  },
  [Language.French]: {
    treesPlanted: "Arbres plantés par les utilisateurs d'Ecosia",
    peopleUsing: "Personnes utilisant Ecosia",
    nativeSpecies: "Espèces indigènes",
    countries: "Pays",
    activeProjects: "Projets actifs",
    discover: "Découvrez nos projets",
  },
};

export default withTranslations(translations)(Component);
