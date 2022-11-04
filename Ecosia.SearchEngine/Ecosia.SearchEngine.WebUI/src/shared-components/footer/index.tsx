import { Grid } from "@mui/material";
import styled from "@emotion/styled";
import {
  FacebookRounded,
  PublicRounded,
  EmojiPeopleRounded,
  PianoRounded,
} from "@mui/icons-material";

export default function Component() {
  return (
    <div>
      <Grid container spacing={2}>
        <Grid item xs={12} xl={12}>
          <LineDiv />
          <SocialContainerDiv>
            <FacebookRounded />
            <PublicRounded />
            <EmojiPeopleRounded />
            <PianoRounded />
          </SocialContainerDiv>
        </Grid>
        <Grid item xs={12} xl={12}>
          <ExplanationDiv>
            Ecosia GmbH does not assume responsibility for the content of sites
            to which it links and the way in which search results are displayed.
            To learn more please read our privacy policy and our terms of
            service.
          </ExplanationDiv>
        </Grid>
      </Grid>
    </div>
  );
}

// Styled Components

const SocialContainerDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
`;

const LineDiv = styled.div`
  border-top: 2px dotted grey;
  text-align: center;
  padding: 10px 50px;
`;

const ExplanationDiv = styled.div`
  text-align: center;
  font-size: small;
  padding: 10px 0;
`;
