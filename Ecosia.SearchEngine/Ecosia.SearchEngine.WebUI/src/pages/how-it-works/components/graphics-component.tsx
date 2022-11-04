import { Grid } from "@mui/material";
import styled from "@emotion/styled";

import { MainTitleDiv } from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";

const Component = ({ t }: { t: ITranslationFunc }) => {
  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <MainTitleDiv>Over 146 million trees planted</MainTitleDiv>
          <ContainerDiv>
            <div>
              <TitleDiv>{"December 2009"}</TitleDiv>
              <SubtitleDiv>{"1.1 sec"}</SubtitleDiv>
              <LineDiv />
              <TitleDiv>{t("plantTree")}</TitleDiv>
            </div>
            <div>
              <TitleDiv>{"over"}</TitleDiv>
              <SubtitleDiv>{"15 million"}</SubtitleDiv>
              <LineDiv />
              <TitleDiv>{t("activeUsers")}</TitleDiv>
            </div>
            <div>
              <TitleDiv>{"over"}</TitleDiv>
              <SubtitleDiv>{"12,101,152"}</SubtitleDiv>
              <LineDiv />
              <TitleDiv>{"EUR invested"}</TitleDiv>
            </div>
            <div>
              <TitleDiv>{"over"}</TitleDiv>
              <SubtitleDiv>{"9000"}</SubtitleDiv>
              <LineDiv />
              <TitleDiv>{t("plantingSites")}</TitleDiv>
            </div>
          </ContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const ContainerDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
  height: 20vh;
`;

const TitleDiv = styled.div`
  text-transform: uppercase;
  padding: 15px 0;
  text-align: center;
`;

const SubtitleDiv = styled.div`
  text-align: center;
`;

const LineDiv = styled.div`
  border: 3px solid #aab74f;
`;

// translations

const translations = {
  [Language.English]: {
    plantTree: "to plant a tree",
    activeUsers: "active users",
    plantingSites: "planting sites",
  },
  [Language.French]: {
    plantTree: "pour planter un arbre",
    activeUsers: "utilisateurs actifs",
    plantingSites: "sites de plantation",
  },
};

export default withTranslations(translations)(Component);
