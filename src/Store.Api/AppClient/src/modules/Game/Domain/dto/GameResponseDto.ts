import { type GameResponse } from "../GameResponse";

export type GameResponseDto = Pick<GameResponse, "image" | "title" | "website" | "price" | "id">;
