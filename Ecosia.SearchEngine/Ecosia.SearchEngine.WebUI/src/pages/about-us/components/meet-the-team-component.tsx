import { useState } from "react";
import { Button, Grid } from "@mui/material";
import styled from "@emotion/styled";

import { MainSubtitleDiv, MainTitleDiv } from "../../../shared-components";
import { Language } from "../../../providers/context";
import { ITranslationFunc, withTranslations } from "../../../helpers";

const Component = ({ t }: { t: ITranslationFunc }) => {
  const [play, setPlay] = useState(false);

  return (
    <section>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <TeamContainerDiv>
            {!play && (
              <>
                <MainTitleDiv>{t("stepInside")}</MainTitleDiv>
                <MainSubtitleDiv>{t("meetTheHumans")}</MainSubtitleDiv>
                <div>
                  <Button
                    variant="contained"
                    color="success"
                    onClick={() => setPlay(true)}
                  >
                    Play
                  </Button>
                </div>
              </>
            )}
            {play && (
              <>
                <MovieVideo controls autoPlay={true}>
                  <source
                    src="https://d3fme2ivr1xlgj.cloudfront.net/240719_ecosia_hiringvideo_subbed_titled.mp4"
                    type="video/mp4"
                  />
                </MovieVideo>
              </>
            )}
          </TeamContainerDiv>
        </Grid>
      </Grid>
    </section>
  );
};

// Styled Components

const TeamContainerDiv = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
  height: 30vh;
`;

const MovieVideo = styled.video`
  max-width: 25vw;
`;

// translations

const translations = {
  [Language.English]: {
    stepInside: "Step inside!",
    meetTheHumans:
      "Meet the humans who make Ecosia and learn what it's like to work here.",
  },
  [Language.French]: {
    stepInside: "Entrez à l'intérieur!",
    meetTheHumans:
      "Rencontrez les humains qui fabriquent Ecosia et découvrez ce que c'est que de travailler ici.",
  },
};

export default withTranslations(translations)(Component);
