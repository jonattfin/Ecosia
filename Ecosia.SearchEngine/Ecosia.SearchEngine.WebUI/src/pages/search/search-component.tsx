import { Box, Tabs, Tab, CircularProgress, Grid } from "@mui/material";
import { useState } from "react";
import {
  Search as SearchIcon,
  Photo as PhotoIcon,
  Newspaper as NewspaperIcon,
} from "@mui/icons-material";

import * as Components from "./components";

export interface SearchProps {
  query: string;
  doSearch: (query: string) => void;
  progress: boolean;
  resultsObject: any;
}

export default function Component({
  query,
  doSearch,
  resultsObject,
  progress,
}: SearchProps) {
  const [value] = useState(0);

  return (
    <Grid container>
      <Grid item xl={4}>
        &nbsp;
      </Grid>
      <Grid item xs={12} xl={4}>
        <section>
          <Components.Search {...{ query, doSearch }} />
          <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
            <Tabs value={value} aria-label="basic tabs example">
              <Tab icon={<SearchIcon />} iconPosition="start" label="Web" />
              <Tab icon={<PhotoIcon />} iconPosition="start" label="Images" />
              <Tab icon={<NewspaperIcon />} iconPosition="start" label="News" />
            </Tabs>
          </Box>
          {showResults(value, progress, resultsObject)}
        </section>
      </Grid>
      <Grid item xl={4}></Grid>
    </Grid>
  );
}

function showResults(value: number, progress: boolean, resultsObject: any) {
  if (progress) return <CircularProgress />;

  if (value === 0) return <Components.SearchList {...resultsObject} />;
}
