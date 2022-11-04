export interface ResultQuery {
  url: string;
  snippet: string;
  name: string;
}

export interface KeyValuePair {
  name: string;
  value: number;
}

export interface ReportData {
  month: string;
  year: number;
  investments: KeyValuePair[];
  countries: KeyValuePair[];
}

export interface Project {
  id: number;
  name: string;
  scope: string;
  description: string;
  title: string;
  treesPlanted: string;
  hectaresRestored: string;
  yearSince: number;
  imageUrl: string;
  tags: Tag[];
}

export interface Tag {
  id: number;
  title: string;
  subtitle: string;
}
