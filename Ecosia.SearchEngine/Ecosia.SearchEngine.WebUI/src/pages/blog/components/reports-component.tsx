import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Chip from "@mui/material/Chip";
import MenuItem from "@mui/material/MenuItem";
import InputLabel from "@mui/material/InputLabel";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import styled from "@emotion/styled";

import dynamic from "next/dynamic";
import _ from "lodash";

import { ITranslationFunc } from "../../../helpers";
import { Grid } from "@mui/material";
import { AppColor } from "../../../shared-components";
import React, { Fragment } from "react";
import { ReportData } from "../../../api/interfaces";

const PieComponent = dynamic(() => import("../../../shared-components/pie"), {
  ssr: false,
});

export interface ReportsProps {
  t: ITranslationFunc;
  reports: ReportData[];
}

export default function Component({ t, reports }: ReportsProps) {
  const [month, setMonth] = React.useState(0);

  const handleMonthChange = (event: SelectChangeEvent) => {
    setMonth(parseInt(event.target.value));
  };

  const getReport = () => {
    return reports[month];
  };

  const currentReport = getReport();

  const getPieData = () => {
    return currentReport.investments.map(({ name, value }) => {
      return {
        id: name,
        label: name,
        value,
      };
    });
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={4} xl={4}>
        <InputLabel id="month-select-label">Month</InputLabel>
        <Select
          labelId="month-select-label"
          id="month-select"
          value={month.toString()}
          label="Month"
          onChange={handleMonthChange}
        >
          {reports.map((report, index) => {
            return (
              <MenuItem key={`month_year${report.month}`} value={index}>
                {`${report.month} ${report.year}`}
              </MenuItem>
            );
          })}
        </Select>
        <CenteredContainerDiv>
          <TitleHeader>{t("title")}</TitleHeader>
          <SubtitleParagraph>{t("aboutTransparency")}</SubtitleParagraph>
        </CenteredContainerDiv>
      </Grid>
      <Grid item xs={4} xl={4}>
        <Card variant="outlined">
          <CardContent>
            <CardDiv>
              <h1>
                {formatMoney(
                  _.sumBy(currentReport.investments, (i) => i.value)
                )}
              </h1>
            </CardDiv>
          </CardContent>
          <CardDiv>{t("totalIncome")}</CardDiv>
        </Card>
        <br />
        <CenteredContainerDiv>
          {currentReport.investments.map(({ name, value }) => {
            return (
              <Fragment key={name}>
                <SubtitleParagraph>
                  {name} {formatMoney(value)}
                </SubtitleParagraph>
              </Fragment>
            );
          })}
        </CenteredContainerDiv>
      </Grid>
      <Grid item xs={4} xl={4}>
        <Card variant="outlined">
          <CardContent>
            <CardDiv>
              <h1>
                {formatMoney(
                  _.sumBy(
                    currentReport.investments.filter((i) =>
                      i.name.toLowerCase().includes("trees")
                    ),
                    (i) => i.value
                  )
                )}
              </h1>
            </CardDiv>
          </CardContent>
          <CardDiv>{t("treesFinanced")}</CardDiv>
        </Card>
        <PieContainerDiv>
          <PieComponent data={getPieData()} />
        </PieContainerDiv>
      </Grid>
      {currentReport.countries.length > 0 && (
        <Grid item xs={4} xl={4}>
          <CenteredContainerDiv>
            Countries:
            {currentReport.countries.map(({ name, value }) => {
              return (
                <ChipContainer key={name}>
                  <Chip label={name} />
                  {formatMoney(value)}
                </ChipContainer>
              );
            })}
          </CenteredContainerDiv>
        </Grid>
      )}
    </Grid>
  );
}

function formatMoney(money: number) {
  return <Fragment>&euro;{money.toLocaleString()}</Fragment>;
}

// Styled Components

const TitleHeader = styled.h1`
  color: ${AppColor.Teal};
  text-transform: uppercase;
`;

const SubtitleParagraph = styled.p`
  font-size: larger;
`;

const ChipContainer = styled.div`
  font-size: larger;
`;

const CardDiv = styled.div`
  text-align: center;
`;

const CenteredContainerDiv = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
`;

const PieContainerDiv = styled.div`
  width: 400px;
  height: 400px;
`;
