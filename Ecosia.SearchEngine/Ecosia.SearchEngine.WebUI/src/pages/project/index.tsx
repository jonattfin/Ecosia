import { useRouter } from "next/router";
import { useQuery } from "react-query";

import { fetchProjectById } from "../../api";
import { Project } from "../../api/interfaces";
import ProjectComponent, { ProjectProps } from "./project-component";

interface IProjectQuery {
  data: Project;
  isLoading: boolean;
  error: any;
}

export default function Index() {
  const { query } = useRouter();
  const { id } = query;

  const {
    data: project,
    isLoading: projectIsLoading,
    error: projectError,
  } = useQuery(["project", id], () => fetchProjectById(id)) as IProjectQuery;

  if (projectIsLoading) return "Loading...";
  if (projectError || !project) return "An error has occurred: ";

  const props: ProjectProps = {
    project,
  };

  return <ProjectComponent {...props} />;
}
