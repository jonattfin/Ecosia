import { Fragment } from "react";
import { useQuery } from "react-query";
import { fetchReportById } from "../../../api";
import FinancialComponent from "./financial-component";

export default function Component({
  language,
}: {
  language: string | undefined;
}) {
  const {
    data: report,
    isLoading: reportIsLoading,
    error: reportError,
  } = useQuery(["report", 5], () => fetchReportById("5"));

  if (reportIsLoading) return <Fragment>Loading...</Fragment>;
  if (reportError || !report) <Fragment>An error has occurred</Fragment>;

  return <FinancialComponent {...{ report, language }} />;
}
