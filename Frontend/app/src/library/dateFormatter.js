export const getFormattedDate = stringDate => {
    return new Date(stringDate).toLocaleTimeString(undefined, {
        weekday: "long",
        year: "numeric",
        month: "long",
        day: "numeric"
      })
}