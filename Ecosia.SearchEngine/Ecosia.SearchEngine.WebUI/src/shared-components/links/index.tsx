import { Grid } from "@mui/material";
import styled from "@emotion/styled";
import Image from "next/image";

import images from "./images";

export default function Links() {
  return (
    <MainDiv>
      <Grid container spacing={2}>
        <Grid item xs={2} xl={2}>
          <div>
            <LogoImage
              src={images.corporationImage}
              alt="b corporation"
            ></LogoImage>
          </div>
        </Grid>
        <Grid item xs={8} xl={8}>
          <ContainerDiv>
            <div>
              <TitleDiv>SITEMAP</TitleDiv>
              <div>
                <a href="#id">News</a>
              </div>
              <div>
                <a href="#id">How Ecosia works</a>
              </div>
              <div>
                <a href="#id">About us</a>
              </div>
              <div>
                <a href="#id">Mobile app</a>
              </div>
              <div>
                <a href="#id">Privacy</a>
              </div>
              <div>
                <a href="#id">Settings</a>
              </div>
            </div>
            <div>
              <TitleDiv>Resources</TitleDiv>
              <div>
                <a href="#id">FAQ</a>
              </div>
              <div>
                <a href="#id">Advertise on Ecosia</a>
              </div>
              <div>
                <a href="#id">Financial reports</a>
              </div>
              <div>
                <a href="#id">Blog</a>
              </div>
              <div>
                <a href="#id">Shop</a>
              </div>
              <div>
                <a href="#id">Press</a>
              </div>
              <div>
                <a href="#id">Jobs</a>
              </div>
            </div>
            <div>
              <TitleDiv>Legal</TitleDiv>
              <div>
                <div>
                  <a href="#id">Privacy policy</a>
                </div>
                <div>
                  <a href="#id">Terms of service</a>
                </div>
                <div>
                  <a href="#id">Imprint</a>
                </div>
              </div>
            </div>
          </ContainerDiv>
        </Grid>
        <Grid item xs={2} xl={2}>
          <TitleDiv>Apps</TitleDiv>
          <div>
            <LogoImage src={images.appStoreImage} alt="app store" />
          </div>
          <div>
            <LogoImage src={images.playStoreImage} alt="play store" />
          </div>
        </Grid>
      </Grid>
    </MainDiv>
  );
}

// Styled Components

const MainDiv = styled.div`
  margin: 25px 0;
`;

const ContainerDiv = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: flex-start;
  height: 15vh;
`;

const TitleDiv = styled.div`
  font-size: medium;
  text-transform: uppercase;
  padding-bottom: 20px;
`;

const LogoImage = styled(Image)`
  width: 10vw;
  max-width: 150px;
`;
