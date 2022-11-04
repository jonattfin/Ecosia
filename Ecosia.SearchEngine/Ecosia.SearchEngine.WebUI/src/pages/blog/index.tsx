import { useRouter } from "next/router";
import { useContext } from "react";
import { useQuery } from "react-query";

import { fetchProjects, fetchReports } from "../../api";
import { LanguageContext } from "../../providers/context";

import BlogComponent, { BlogProps } from "./blog-component";

export default function Component() {
  const router = useRouter();
  const { id } = router.query;

  const language = useContext(LanguageContext);

  const {
    isLoading: projectsAreLoading,
    error: projectsError,
    data: projects,
  } = useQuery("projects", fetchProjects);

  const {
    isLoading: reportsAreLoading,
    error: reportsError,
    data: reports,
  } = useQuery("reports", fetchReports);

  if (projectsAreLoading || reportsAreLoading) return "Loading...";
  if (projectsError || reportsError || !projects || !reports)
    return "An error has occurred...";

  const props: BlogProps = {
    projects,
    reports: [...reports].reverse(),
    language,
    id: id == "projects" ? 0 : 1,
  };

  return <BlogComponent {...props}></BlogComponent>;
}
