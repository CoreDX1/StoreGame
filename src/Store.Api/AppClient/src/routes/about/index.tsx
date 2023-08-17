import { component$, useSignal, useTask$, $ } from "@builder.io/qwik";

interface GameModel {
  id: number;
  title: string;
  developerName: string;
  linkGame: string;
  platformName: string;
  releaseDate: string;
  description: string;
  price: number;
  stock: number;
  imageUrl: null;
}

export default component$(() => {
  const responseJson = useSignal<GameModel[]>();

  const apiService = $(async () => {
    const api = "http://localhost:5099/api/Game/List";
    const data = await fetch(api, {
      method: "GET",
    });
    return await data.json();
  });

  useTask$(async () => {
    responseJson.value = await apiService();
  });

  return (
    <div class="border-blue-500 border-2 flex justify-center">
      <div class="border-red-700 border-2 w-[900px] grid grid-cols-2 gap-4 pt-5 m-10">
        {responseJson.value?.map((game) => (
          <div key={game.id} class="flex justify-center items-center">
            <div class="bg-white w-full shadow-md">
              <img
                width={500}
                height={0}
                src={`/Imagen/${game.imageUrl}`}
              ></img>
              <div class="p-5">
                <h2 class="text-2xl mb-2 font-normal">{game.title}</h2>
                <p class="text-2xl text-black font-bold mb-2 text-right">
                  ${game.price}
                </p>
                <button
                  class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                  onClick$={() => {
                    window.open(game.linkGame);
                  }}
                >
                  Buy
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
});
