import { Grid } from "@mui/material";
import styled from "@emotion/styled";
import Head from "next/head";

import * as Components from "./components";
import { AppColor } from "../../shared-components";
import { Language } from "../../providers/context";
import { ResultQuery } from "../../api/interfaces";

export interface HomeComponentProps {
  q: string;
  counter: number;
  language?: Language;
  onSearch: (query: string) => void;
  onSearchValueSelected: (query: string) => void;
  data: ResultQuery[],
}

export default function Component({
  q,
  counter,
  onSearch,
  onSearchValueSelected,
  language,
  data
}: HomeComponentProps) {
  const title = "Ecosia - The search engine that plants trees";

  return (
    <section>
      <Head>
        <title>{title}</title>
        <meta property="og:title" content={title} key="title" />
      </Head>
      <Grid container>
        {/* Search section */}
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        <Grid item xs={12} xl={6}>
          <Components.SearchComponent {...{ q, counter, onSearch, onSearchValueSelected, language, data }} />
        </Grid>
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        {/* Search section */}

        {/* Countries section */}
        <BlueGrid item xl={3}>
          &nbsp;
        </BlueGrid>
        <BlueGrid item xs={12} xl={6}>
          <Components.CountriesComponent {...{ language }} />
        </BlueGrid>
        <BlueGrid item xl={3}>
          &nbsp;
        </BlueGrid>
        {/* Countries section */}

        {/* Map section */}
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        <Grid item xs={12} xl={6}>
          <Components.MapComponent {...{ counter, language }} />
        </Grid>
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        {/* Map section  */}

        {/* Financial section */}
        <BlueGrid item xl={3}>
          &nbsp;
        </BlueGrid>
        <BlueGrid item xl={6}>
          {/* <Components.FinancialContainer {...{ language }} /> */}
        </BlueGrid>
        <BlueGrid item xl={3}>
          &nbsp;
        </BlueGrid>
        {/* Financial section */}

        {/* Why choose us section */}
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        <Grid item xl={6}>
          <Components.WhyChooseUsComponent {...{ language }} />
        </Grid>
        <Grid item xl={3}>
          &nbsp;
        </Grid>
        {/* Why choose us section */}
        <Grid item xs={12} xl={12}>
          <section>
            <Components.JoinUsComponent {...{ language }} />
          </section>
        </Grid>
      </Grid>
    </section>
  );
}

// Styled Components

const BlueGrid = styled(Grid)`
  background-color: ${AppColor.AliceBlue};
`;
