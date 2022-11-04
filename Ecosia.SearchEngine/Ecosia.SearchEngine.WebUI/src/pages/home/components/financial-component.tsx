import { Grid } from "@mui/material";
import ChevronRightIcon from "@mui/icons-material/ChevronRight";
import Link from "next/link";
import dynamic from "next/dynamic";
import styled from "@emotion/styled";

import {
  MainTitleDiv,
  MainSubtitleDiv,
  LinkDiv,
} from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";
import { ReportData } from "../../../api/interfaces";

const PieComponent = dynamic(() => import("../../../shared-components/pie"), {
  ssr: false,
});

const Component = ({
  t,
  report,
}: {
  t: ITranslationFunc;
  report: ReportData;
}) => {
  return (
    <MainSection>
      <Grid container spacing={2}>
        <Grid item xs={6} xl={6}>
          <MainTitleDiv data-test="reports-title">
            {t("monthlyReports")}
          </MainTitleDiv>
          <MainSubtitleDiv>
            {t("ourRevenue").replace(
              "[month]",
              `${report.month} ${report.year}`
            )}
          </MainSubtitleDiv>
          <ContentDiv>{t("reportsDescription")}</ContentDiv>
        </Grid>
        <Grid item xs={0} xl={2}>
          &nbsp;
        </Grid>
        <Grid item xs={6} xl={4}>
          <PieContainerDiv>
            <PieComponent data={getPieData(report)} />
          </PieContainerDiv>
        </Grid>
        <Grid item xs={12} xl={12}>
          <LinkDiv>
            <Link href="/blog/reports">
              <a data-test="explore-reports">
                {t("exploreReports")}
                <ChevronRightIcon fontSize="small" />
              </a>
            </Link>
          </LinkDiv>
        </Grid>
      </Grid>
    </MainSection>
  );
};

const getPieData = (report: ReportData) => {
  return report.investments.map(({ name, value }) => {
    return {
      id: name,
      label: name,
      value,
    };
  });
};

// Styled Components

const MainSection = styled.section`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 50vh;
`;

const ContentDiv = styled.div`
  padding-top: 20px;
  font-size: larger;
`;

const PieContainerDiv = styled.div`
  width: 300px;
  height: 300px;
`;

// translations

const translations = {
  [Language.English]: {
    monthlyReports: "Monthly financial reports",
    ourRevenue: "Our revenue in [month]",
    reportsDescription:
      "Our monthly reports show how much ad revenue we made from your searches, how we spent it, and how many trees this helped us plant.",
    exploreReports: "Explore our financial reports ",
  },
  [Language.French]: {
    monthlyReports: "Rapports financiers mensuels",
    ourRevenue: "Notre chiffre d'affaires en [month]",
    reportsDescription:
      "Nos rapports mensuels montrent combien de revenus publicitaires nous avons tirés de vos recherches, comment nous les avons dépensés et combien d'arbres cela nous a aidés à planter.",
    exploreReports: "Explorez nos rapports financiers",
  },
};

export default withTranslations(translations)(Component);
