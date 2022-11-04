import { useState, useEffect, useContext } from "react";
import { useRouter } from "next/router";
import useWebSocket from "react-use-websocket";
import { debounce } from "lodash";

import HomeComponent from "./home-component";
import { LanguageContext } from "../../providers/context";
import { searchByQueryAsync, wssBaseUrl } from "../../api";
import { ResultQuery } from "../../api/interfaces";

export default function Component() {
  const [counter, setCounter] = useState(1500);
  const [query, setQuery] = useState("");
  const [data, setData] = useState<ResultQuery[]>([]);

  const [socketUrl] = useState(wssBaseUrl);
  const { sendJsonMessage, lastMessage } = useWebSocket(socketUrl);

  const onSearch = (q: string) => {
    setQuery(q);
    console.log(`called with ${q}`);
  };

  const router = useRouter();
  const onSearchValueSelected = (q: string) => router.push(`/search/${q}`);

  useEffect(() => {
    if (!lastMessage) 
      return;

    const dataObj = JSON.parse(lastMessage.data);
    console.log(dataObj);
    setCounter(dataObj.data || 0);
  }, [lastMessage]);

  useEffect(() => {
    async function fetchData() {
      const fetchedData = await searchByQueryAsync(query);
      setData(fetchedData);
    }
    if (query.length > 0) fetchData();
  }, [query]);

  useEffect(() => {
    sendJsonMessage({ event: "events" });
  }, []);

  const language = useContext(LanguageContext);

  return (
    <HomeComponent
      {...{
        q: query,
        counter,
        onSearch: debounce(onSearch, 10),
        onSearchValueSelected,
        language,
        data,
      }}
    />
  );
}
