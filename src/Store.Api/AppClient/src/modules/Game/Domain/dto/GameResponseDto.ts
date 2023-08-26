import { type GameResponse } from "../GameResponse";

export type GameResponseDto = Pick<GameResponse, "imagen" | "title" | "website" | "price" | "id">;
